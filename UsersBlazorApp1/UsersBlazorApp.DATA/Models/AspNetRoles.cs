﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersBlazorApp.Data.Models;

public partial class AspNetRoles
{
	[Key]
	public int Id { get; set; }

	[StringLength(256)]
	public string? Name { get; set; }

	[InverseProperty("Role")]
	public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaims>();

	[InverseProperty("Roles")]
	public virtual ICollection<AspNetUsers> Users { get; set; } = new List<AspNetUsers>();
}
