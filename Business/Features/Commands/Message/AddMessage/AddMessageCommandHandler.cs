using DataAccess.Abstract.Message;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Commands.Message.AddMessage
{
    public class AddMessageCommandHandler : IRequestHandler<AddMessageCommandRequest, AddMessageCommandResponse>
    {
        private readonly IMessageWriteRepository _messageWriteRepository;

        public AddMessageCommandHandler(IMessageWriteRepository messageWriteRepository)
        {
            _messageWriteRepository = messageWriteRepository;
        }

        public async Task<AddMessageCommandResponse> Handle(AddMessageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Message != null)
            {
                await _messageWriteRepository.AddAsync(new Entities.Abstract.Message()
                {
                    ChatId = Guid.Parse(request.ChatId),
                    SenderUserId = request.SenderUserId,
                    MessageContent = request.Message
                }
                );
                await _messageWriteRepository.SaveAsync();
                //signal R işlemleride olucak şimdilik böyle bırakıyorum onu en son yapıcam
                return new AddMessageCommandResponse { isSucceded = true, Message = "Başarılı" };
            }
            else
                return new AddMessageCommandResponse() { isSucceded = false, Message = "Boş Mesaj Gönderilemez" };


            throw new NotImplementedException();
        }
    }
}
