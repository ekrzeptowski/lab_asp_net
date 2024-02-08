using Data.Entities;
using lab3_app.Models;

namespace lab3_app.Mappers;

public class ReviewMapper
{
    public static Review FromEntity(ReviewEntity entity)
    {
        return new Review
        {
            Id = entity.Id,
            ProductId = entity.ProductId,
            UserId = entity.UserId,
            Comment = entity.Comment,
            Rating = entity.Rating
        };
    }

    public static ReviewEntity ToEntity(Review review)
    {
        return new ReviewEntity
        {
            Id = review.Id,
            ProductId = review.ProductId,
            UserId = review.UserId,
            Comment = review.Comment,
            Rating = review.Rating
        };
    }
    
}