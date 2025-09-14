/*
 * \file PersonalData.cs
 * \brief Value Object representing user's personal data 
 *
 * The PersonalData class defines a value object that encapsulates
 * identity-related information of the user
 * 
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;

namespace Transacto.Domain.Users.ValueObjects;

[Owned]
public class PersonalData
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    
    /// <summary>
    /// National identification number used for user identity verification
    /// Social Security Number (SSN); in Poland, this is PESEL
    /// </summary>
    public string Ssn { get; private set; } = default!;
    public string Gender { get; private set; } = default!;
    public DateOnly DateOfBirth { get; private set; }
    public string PlaceOfBirth { get; private set; } = default!;
    public string Nationality { get; private set; } = default!;
    public string PhoneNumber { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    
    private PersonalData() {}

    public PersonalData(
        string firstName,
        string lastName,
        string ssn,
        string gender,
        DateOnly dateOfBirth,
        string placeOfBirth,
        string nationality,
        string phoneNumber,
        Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Ssn = ssn;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        PlaceOfBirth = placeOfBirth;
        Nationality = nationality;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}