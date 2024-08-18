

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;
public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public Boolean IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public ValueObjects.Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public string ImageUrl { get; private set; }
    public Location Location { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
       
        DinnerStatus status,
        Boolean isPublic,
        int maxGuests,
        ValueObjects.Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        List<Reservation> reservations,
        DateTime createdDateTime,
        DateTime updatedDateTime
        ):base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime=null;
        EndedDateTime=null;
        Status =  status;
        IsPublic = isPublic; 
        MaxGuests = maxGuests;
        Price = price;
        HostId=hostId;
        MenuId=menuId;
        ImageUrl=imageUrl;
        Location=location;
        _reservations=reservations;
        CreatedDateTime=createdDateTime;
        UpdatedDateTime=updatedDateTime;
    }
    
    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
      
        
        Boolean isPublic,
        int maxGuests,
        ValueObjects.Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        List<Reservation> reservations
        
    )
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            DinnerStatus.Upcoming,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            reservations,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private Dinner()
    {

    }   
#pragma warning restore CS8618
    
}