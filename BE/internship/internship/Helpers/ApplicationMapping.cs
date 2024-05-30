using AutoMapper;
using internship.Database;
using internship.Model;

namespace internship.Helper
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping() {
            CreateMap<User,UserModel>().ReverseMap();
            CreateMap<Order,OrderModel>().ReverseMap();
            CreateMap<Order_detail,OrderDetailModel>().ReverseMap();
            CreateMap<Item,ItemModel>().ReverseMap();
            CreateMap<Catagory,CatagoryModel>().ReverseMap();
        } 
    }
}
