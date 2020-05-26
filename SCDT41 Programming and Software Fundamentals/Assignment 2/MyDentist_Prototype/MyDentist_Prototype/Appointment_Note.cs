using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Appointment_Note
    {
        string note;
        Dentist dentist;
        Nurse nurse;
        DateTime when;

        public Appointment_Note(string note, Dentist dentist, Nurse nurse, DateTime when) //object for appointment notes
        {
            this.note = note;
            this.dentist = dentist;
            this.nurse = nurse;
            this.when = when;
        }
        public string Note { get => note; set => note = value; }
        public Dentist Dentist { get => dentist; set => dentist = value; }
        public Nurse Nurse { get => nurse; set => nurse = value; }
        public DateTime When { get => when; set => when = value; }
    }
}
