/*
 * \file Address.cs
 * \brief Value Object representing a user's address
 *
 * The Address class defines a value object that holds address data,
 * which is a part of the user's personal data
 * 
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;

namespace Transacto.Domain.Users.ValueObjects;

[Owned]
public class Address
{
    public string Street { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string PostalCode { get; private set; } = default!;
    public string Country { get; private set; } = default!;
    
    private Address() {}

    public Address(string street, string city, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street is required");
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required");
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code is required");
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country is required");
        
        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    public override string ToString() => $"{Street}, {PostalCode} {City}, {Country}";
}