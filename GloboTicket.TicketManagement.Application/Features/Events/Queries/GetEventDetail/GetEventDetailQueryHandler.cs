﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IAsyncRepository<Category> categoryRepository;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.categoryRepository = categoryRepository;
        }

        public IAsyncRepository<Category> CategoryRepository { get; }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await eventRepository.GetByIdAsync(request.Id);
            var eventDetailDto = mapper.Map<EventDetailVm>(@event);

            var category = await categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetailDto.Category = mapper.Map<CategoryDto>(category);
            return eventDetailDto;
        }
    }
}
