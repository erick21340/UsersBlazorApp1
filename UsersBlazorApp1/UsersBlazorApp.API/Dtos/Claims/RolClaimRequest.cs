﻿namespace UserBlazorApp.API.Dtos.Claims;

public class RolClaimRequest
{
	public int RoleId { get; set; }

	public string? ClaimType { get; set; }

	public string? ClaimValue { get; set; }
}