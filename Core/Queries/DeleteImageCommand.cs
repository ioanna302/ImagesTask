using MediatR;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Core.Queries;
public class DeleteImageCommand : IRequest
{
    public int imageID;

}

public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
{
    private readonly IImagesService _service;


    public DeleteImageCommandHandler(IImagesService service)
    {
        _service = service;
    }

    public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        if (request.imageID==null)
        {
            return Unit.Value;
        }
        await _service.DeleteImage(request.imageID);
        await _service.SaveChangesAsync();
        return Unit.Value;
    }
}