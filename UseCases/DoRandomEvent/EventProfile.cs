using AutoMapper;
using CSharpClickerWeb.UseCases.DoRandomEvent;

namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<RandomEvent, EventDto>();
        }
    }
}
