﻿using WhenItsDone.Common.Enums;

namespace WhenItsDone.DTOs.WorkerVIewsDTOs
{
    public class WorkerDetailInformationDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public int Age { get; set; }

        public int Rating { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
