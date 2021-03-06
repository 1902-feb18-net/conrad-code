﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoGameOrderSystem.Library
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;

        public int Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if( value == null)
                {
                    throw new ArgumentNullException("First Name cannot be empty.", nameof(value));
                }

                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First Name cannot be empty.", nameof(value));
                }

                _lastName = value;
            }
        }

        public DateTime birthday { get; set; }

        public Location StoreLocation { get; set; }

        List<Order> Orders { get; set; } = new List<Order>();


    }
}
