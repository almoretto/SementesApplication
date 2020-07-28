/*
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
       
        
        public void RemoveTeamSchedule(TeamSchedule teamSchedule)
        {
            _dBContext.TeamSchedules.Remove(teamSchedule);
            _dBContext.SaveChanges();
        }
            
    }
}*/