using AutoMapper;
using ECommerceAPI.DTOs;
using ECommerceAPI.Models;
namespace ECommerceAPI.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            // Order to OrderDTO mapping
            // Source:  Order
            // Destination: OrderDTO
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddres))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.ShippedDate.HasValue ? src.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null))
                .ForMember(dest => dest.TrackingDetail, opt => opt.MapFrom(src => src.TrackingDetail));

            // Mapping configuration for order items
            // Maps the OrderItem entity to OrderItemDTO for data transfer
            CreateMap<OrderItem, OrderItemDTO>()
                // Map the Product.Name property to OrderItemDTO.ProductName
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))

                // Map the Product.Price property to OrderItemDTO.ProductPrice
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))

                // Map the ProductPrice
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));

            // Mapping configuration for customer addresses
            // Maps the Address entity to AddressDTO for data transfer
            CreateMap<Address, AddressDTO>();

            // Mapping configuration for Tracking details
            CreateMap<TrackingDetail, TrackingDetailDTO>()
                .ForMember(dest => dest.TrackingNumber, opt => opt.NullSubstitute("Tracking not available"));

            // Mapping configuration for creating orders
            // Maps the OrderCreateDTO (data received from client) to the Order entity
            // Source: OrderCreateDTO
            // Destination: Order
            CreateMap<OrderCreateDTO, Order>()
                // Set the OrderDate to the current date and time (DateTime.Now) when creating an order
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.Now))

                // Ignore the Amount property during the mapping, as it will be calculated later
                // .ForMember(dest => dest.Amount, opt => opt.Ignore())

                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending")) // Fixed value for Status while creating Order

                // Map the list of OrderItemCreateDTO to the OrderItems property in the Order entity
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items));

            // Mapping configuration for creating order items
            // Maps the OrderItemCreateDTO (data received from client) to the OrderItem entity
            CreateMap<OrderItemCreateDTO, OrderItem>(); //Propery Mapping is not required as both contains the same property names
        }
    }
}
