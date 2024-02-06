using NLWExpertAPI.Mappers.Interfaces;
using NLWExpertAPI.Models;
using NLWExpertAPI.Models.Dto;
using Riok.Mapperly.Abstractions;

namespace NLWExpertAPI.Mappers;

[Mapper]
public partial class ItemMapper : IItemMapper
{
    public partial ItemDto ToDto(Item item);
}