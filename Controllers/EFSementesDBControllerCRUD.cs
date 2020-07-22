using System.Collections.Generic;
using System.Linq;

namespace SementesApplication
{
    public class EFSementesDBControllerCRUD
    {
        readonly CFSementesDBContext _dBContext = new CFSementesDBContext();
        
        public List<Volunteer> FetchVolunteers()
        {
            return _dBContext.Volunteers.ToList();
        }

        public List<AssistedEntities> FetchAssistedEntities()
        {
            return _dBContext.AssistedEntities.ToList();
        }
        public List<Actions> FetchActions()
        {
            return _dBContext.Actions.ToList();
        }
        public List<TeamAction> FetchTeamActions()
        {
            return _dBContext.TeamActions.ToList();
        }
        public List<TeamSchedule> FetchTeamSchedule()
        {
            return _dBContext.TeamSchedules.ToList();
        }
        public int AddVolunteer(Volunteer volunteer, Address address, City city)
        {
            
            _dBContext.Volunteers.Add(volunteer);
            _dBContext.SaveChanges();

            return volunteer.VolunteerID;
        }
        public int AddAssistedEntities(AssistedEntities assistedentities)
        {
            _dBContext.AssistedEntities.Add(assistedentities);
            _dBContext.SaveChanges();
            return assistedentities.AssistedEntitiesID;
        }

        public int AddCity (City city)
        {
            _dBContext.Cities.Add(city);
            _dBContext.SaveChanges();
            return city.CityID;
        }
        public int AddAddress(Address address)
        {
            _dBContext.Adresses.Add(address);
            _dBContext.SaveChanges();
            return address.AddressID;

        }
        public int AddActions (Actions action)
        {
            _dBContext.Actions.Add(action);
            _dBContext.SaveChanges();
            return action.ActionID;
        }
        public int AddVolunteerTeamSchedule(TeamSchedule volunteerLeaseTime)
        {
            _dBContext.TeamSchedules.Add(volunteerLeaseTime);
            _dBContext.SaveChanges();
            return volunteerLeaseTime.TeamScheduleID;
        }

        public void RemoveAssistedEntities(AssistedEntities entity)
        {
            
            _dBContext.AssistedEntities.Remove(entity);
            _dBContext.SaveChanges();
        }
        public void RemoveActions(Actions action)
        {
            _dBContext.Actions.Remove(action);
            _dBContext.SaveChanges();
        }
        public void RemoveTeamAction(TeamAction teamAction)
        {
            _dBContext.TeamActions.Remove(teamAction);
            _dBContext.SaveChanges();
        }
        public void RemoveTeamSchedule(TeamSchedule teamSchedule)
        {
            _dBContext.TeamSchedules.Remove(teamSchedule);
            _dBContext.SaveChanges();
        }
            
    }
}