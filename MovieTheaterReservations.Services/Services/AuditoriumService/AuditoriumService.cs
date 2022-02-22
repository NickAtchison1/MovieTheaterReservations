using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.Auditorium;

namespace MovieTheaterReservations.Services.Services.AuditoriumService
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly ApplicationDbContext _context;

        public AuditoriumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateAuditorium(AuditoriumCreate auditoriumCreate, string userId)
        {
            var auditoriumEntity = new Auditorium()
            {
                Name = auditoriumCreate.Name,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now,
            };
            _context.Auditoriums.Add(auditoriumEntity);
            return _context.SaveChanges() > 0;

        }

        public IEnumerable<AuditoriumListItem> GetAllAuditoriums()
        {
            var query = _context.Auditoriums
                .Select(a => new AuditoriumListItem()
                {
                    Id = a.Id,
                    Name = a.Name,
                }).ToList();

            return query;
        }

        public AuditoriumDetail GetAuditoriumById(int id)
        {
            var auditoriumEntity = _context.Auditoriums.Single(a => a.Id == id);
            var detail = new AuditoriumDetail()
            {
                Id = auditoriumEntity.Id,
                Name = auditoriumEntity.Name,
            };
            return detail;
           
        }

        public bool UpdateAuditorium(AuditoriumEdit auditoriumEdit, string userId)
        {
            var auditoriumToUpdate = _context.Auditoriums.Single(a => a.Id == auditoriumEdit.Id);
            auditoriumToUpdate.Id = auditoriumEdit.Id;
            auditoriumToUpdate.Name = auditoriumEdit.Name;
            auditoriumToUpdate.CreatedBy = auditoriumToUpdate.CreatedBy;
            auditoriumToUpdate.CreatedDate = auditoriumToUpdate.CreatedDate;
            auditoriumToUpdate.UpdatedBy = userId;
            auditoriumToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteAuditorium(int id)
        {
            var auditoriumToDelete = _context.Auditoriums.Single(a => a.Id == id);
            _context.Auditoriums.Remove(auditoriumToDelete);
            return _context.SaveChanges() > 0;
        }
    }
}
