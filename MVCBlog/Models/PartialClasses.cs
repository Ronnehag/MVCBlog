using Microsoft.AspNetCore.Mvc;

namespace MVCBlog.Models
{
    [ModelMetadataType(typeof(PostMetaData))]
    public partial class Post
    {
        // This is a part of the DbContext-Model Post.
        // This class is only for mapping the MetaData with the migration.
        // Do not change this class directly, modification of validation rules will be in PostMetaData.
    }
}
