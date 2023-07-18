using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;

namespace DataAccessLibrary
{
    public class AppointmentRepository
    {
        private List<AppointmentMaster> appointments;

        public AppointmentRepository()
        {
            appointments = new List<AppointmentMaster>();
        }

        public List<AppointmentMaster> GetAppointments()
        {
            return appointments;
        }

        public void SaveAppointment(AppointmentMaster appointment)
        {
            if (appointment.Id > 0)
            {
                var existingAppointment = appointments.Find(a => a.Id == appointment.Id);
                if (existingAppointment != null)
                {
                    existingAppointment.PId = appointment.PId;
                    existingAppointment.DId = appointment.DId;
                    existingAppointment.Date = appointment.Date;
                    existingAppointment.TimeSlot = appointment.TimeSlot;
                    existingAppointment.Status = appointment.Status;
                    existingAppointment.Remark = appointment.Remark;
                }
            }
            else
            {
                appointment.Id = appointments.Count > 0 ? appointments.Max(a => a.Id) + 1 : 1;
                appointments.Add(appointment);
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            var appointmentToRemove = appointments.Find(a => a.Id == appointmentId);
            if (appointmentToRemove != null)
            {
                appointments.Remove(appointmentToRemove);
            }
        }
    }
}
