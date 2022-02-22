using MovieTheaterReservations.DisplayModels.Auditorium;

namespace MovieTheaterReservations.Services.Services.AuditoriumService
{
    public interface IAuditoriumService
    {
        bool CreateAuditorium(AuditoriumCreate auditoriumCreate, string userId);
        bool DeleteAuditorium(int id);
        IEnumerable<AuditoriumListItem> GetAllAuditoriums();
        AuditoriumDetail GetAuditoriumById(int id);
        bool UpdateAuditorium(AuditoriumEdit auditoriumEdit, string userId);
    }
}