using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Win10_task1.Models
{
    class Process : DomainObject
    {

        public Process()
        {
            Id = Guid.NewGuid();
            Name = "Task...";
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(50)]
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [MaxLength(300)]
        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                    return;
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private bool _ready;

        public bool Ready
        {
            get { return _ready; }
            set
            {
                if (_ready == value)
                    return;
                _ready = value;
                OnPropertyChanged(nameof(Ready));
            }
        }

        public virtual User User { get; set; }
        public virtual ICollection<SubTask> SubTasks { get; set; }
    }
}
