using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Win10_task1.Models
{
    class User : DomainObject
    {
        public User()
        {
            _id = Guid.NewGuid();
        }

        public User(string lastName, string firstName, string surName, string login, string password)
        {
            _id = Guid.NewGuid();
            LastName = lastName;
            FirstName = firstName;
            SurName = surName;
            Login = login;
            PasswordHash = password;
        }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        private string _surName;

        public string SurName
        {
            get { return _surName; }
            set
            {
                if (_surName != value)
                {
                    _surName = value;
                    OnPropertyChanged(nameof(SurName));
                }
            }
        }

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        private string _password;

        public string PasswordHash
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(PasswordHash));
                }
            }
        }

        public virtual ICollection<Process> Processes { get; set; }
    }
}
