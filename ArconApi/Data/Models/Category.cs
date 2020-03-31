namespace ArconApi.Data.Models{
    public class Category{
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int IsActive { get; set; }

        internal void SetCategoryName(string categoryName)
        {
            
            this.CategoryName=categoryName;
        }
          internal void SetIsActive(int isActive)
        {
            
            this.IsActive=isActive;
        }
         public sealed class Builder
        {
            private readonly Category _category;
            public Builder(string categoryName){
                _category = new Category{
                    CategoryName=categoryName
                };
            }

            public Builder WithIsActive(int isActive){
                _category.IsActive=isActive;
                return this;
            }
            public Category Build(){
                return _category;
            }
        }

    }
}