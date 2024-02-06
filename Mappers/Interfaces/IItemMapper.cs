using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;

namespace NLWExpertAPI.Mappers.Interfaces;

public interface IItemMapper
{
    public abstract ItemDto ToDto(Item item);
}