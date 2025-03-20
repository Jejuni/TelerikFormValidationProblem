using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace TelerikTest.Client.Models;

public class ModelValidator : AbstractValidator<Model>
{
    private readonly List<int> _values = [1, 2, 3];

    public ModelValidator()
    {
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.Brand)
            .Must(_values.Contains)
            .WithMessage($"Brand must be one of: {string.Join(", ", _values)}");
    }
}

public sealed record Model
{
    public static Model Empty => new() { Id = Guid.Empty, Name = "", Brand = 0 };

    public required string Name { get; init; }

    public required int Brand { get; set; }

    [Display(AutoGenerateField = false)] public required Guid Id { get; init; }
}