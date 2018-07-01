using BusinessRules.Interfaces;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
    public class QuartoBusiness : BaseValidator<Quarto>, IEntityBase<Quarto>, IQuartoRules
    {
        public override void Validate(Quarto item)
        {
            if(string.IsNullOrWhiteSpace(item.CodigoQuarto))
            {
                base.AddError(new ErrorField() { Message = "Favor, informe o código do quarto", Field = "CodigoQuarto" });
            }
            else if(item.CodigoQuarto.Length > 5)
            {
                base.AddError(new ErrorField() { Message = "O Código do quarto não pode conter mais de 5 caracteres", Field = "CodigoQuarto" });
            }
            base.Validate(item);
        }

        public void Add(Quarto item)
        {
            Validate(item);
            //Se chegou aqui, pode dale
            using(PutsContext db = new PutsContext())
            {
                db.Quartos.Add(item);
                db.SaveChanges();
            }
        }

        public void Edit(Quarto item)
        {
            Validate(item);
            //Se chegou aqui, pode dale
            using (PutsContext db = new PutsContext())
            {
                db.Entry<Quarto>(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Quarto item)
        {
            using (PutsContext db = new PutsContext())
            {
                Quarto quarto = db.Quartos.Find(item.ID);
                if(quarto.Servicos == null || quarto.Servicos.Count == 0)
                {
                    db.Entry<Quarto>(quarto).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public Quarto GetByID(int id)
        {
            using(PutsContext db = new PutsContext())
            {
                return db.Quartos.Find(id);
            }
        }

        public IList<Quarto> GetAll()
        {
            using (PutsContext db = new PutsContext())
            {
                return db.Quartos.AsNoTracking().ToList();
            }
        }

        public IList<Quarto> GetQuartosDisponiveis()
        {
            using (PutsContext db = new PutsContext())
            {
                return db.Quartos.AsNoTracking().Where(c => !c.EstaOcupado).ToList();
            }
        }

        public IList<Quarto> GetQuartosOcupados()
        {
            using (PutsContext db = new PutsContext())
            {
                return db.Quartos.AsNoTracking().Where(c => c.EstaOcupado).ToList();
            }
        }
    }
}
