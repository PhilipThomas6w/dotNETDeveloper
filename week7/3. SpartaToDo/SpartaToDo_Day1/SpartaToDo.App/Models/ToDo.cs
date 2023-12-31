﻿using System.ComponentModel.DataAnnotations;

namespace SpartaToDo.App.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]  // server side validation
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Complete?")]
        public bool Complete { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime DateCreated { get; init; } = DateTime.Now;



    }
}
