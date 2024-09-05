﻿namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Album
{
    public Album()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.AlbumNameMaxLength)]
    public string Name { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    [NotMapped]
    public decimal Price
        => this.Songs.Sum(s => s.Price);

    // Foreign keys
    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public virtual Producer? Producer { get; set; }

    // Navigation properties
    public virtual ICollection<Song> Songs { get; set; }
}
