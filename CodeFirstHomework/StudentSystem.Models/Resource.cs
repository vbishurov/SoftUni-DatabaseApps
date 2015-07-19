namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        private ICollection<License> licenses;

        public Resource()
        {
            this.licenses = new HashSet<License>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        [Required]
        public string URL { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public ICollection<License> Licenses
        {
            get
            {
                return this.licenses;
            }

            set
            {
                this.licenses = value;
            }
        }
    }
}
