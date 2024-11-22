using GETAF.Models.Context;
using GETAF.Models.Entities;

namespace GETAF.Models.ViewModel {
    public class TarefaViewModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
        public int? CdStatus { get; set; }

        public int UsuarioId { get; set; }
        public int GrupoId { get; set; }
        public int DificuldadeId { get; set; }

        public Tarefa? CriarTarefa(AppDbContext _context) {
            try {
                var tarefa = new Tarefa
                {
                    Nome = Nome,
                    Descricao = Descricao,
                    DtInicio = DateTime.Now,
                    DtFim = DtFim,
                    CdStatus = CdStatus,
                    UsuarioId = UsuarioId,
                    GrupoId = GrupoId,
                    DificuldadeId = DificuldadeId
                };
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Tarefa? AtualizarTarefa(AppDbContext _context) {
            try { 
            var tarefa = _context.Tarefas.Find(Id);
                if (tarefa == null) return null;
                
                tarefa.Nome = Nome;
                tarefa.Descricao = Descricao;
                tarefa.DtFim = DtFim;
                tarefa.DificuldadeId = DificuldadeId;
                if(CdStatus != null)
                tarefa.CdStatus = CdStatus;

                _context.Tarefas.Update(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Tarefa? AtualizarStatus(AppDbContext _context) {
            try {
                var tarefa = _context.Tarefas.Find(Id);
                if (tarefa == null) return null;

                if (CdStatus != null)
                    tarefa.CdStatus = CdStatus;

                _context.Tarefas.Update(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Tarefa? ExcluirTarefa(AppDbContext _context) {
            try {
                var tarefa = _context.Tarefas.Find(Id);
                if (tarefa == null) return null;

                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            catch (Exception ex) {
                return null;
            }
        }


        public List<Tarefa> ListarTarefas(AppDbContext _context) {
            try {
                return _context.Tarefas.Where(x => x.GrupoId == GrupoId).ToList();
            }
            catch (Exception ex) {
                return new List<Tarefa>();
            }
        }

        public List<Tarefa> ListarTarefasGeral(AppDbContext _context, int usuarioId)
        {
            try
            {
                var grupos = _context.Grupos
                    .Where(g => g.GrupoUsuarios.Any(gu => gu.UsuarioId == usuarioId))
                    .ToList(); 
                List<int> idsGrupos  = grupos.Select(x => x.Id).ToList();
                return _context.Tarefas.Where(x => idsGrupos.Contains(x.GrupoId)).ToList();
            }
            catch (Exception ex)
            {
                return new List<Tarefa>();
            }
        }
}
}