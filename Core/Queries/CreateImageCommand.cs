using MediatR;
using ImagesTask.Core.DTOs;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Core.Queries;
public class CreateImageCommand : IRequest<int>
{
    public ImageDTO? imageFile { get; set; }
}

public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, int>
{
    private readonly IImagesService _service;


    public CreateImageCommandHandler(IImagesService service)
    {
        _service = service;
    }

    public async Task<int> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        if (request.imageFile==null)
        {
            throw new ArgumentNullException(nameof(request.imageFile));
        }
        var result = await _service.AddNewImage(request.imageFile);
        await _service.SaveChangesAsync();

        return result;
    }
}