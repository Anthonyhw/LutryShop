using AutoMapper;
using LutryShop.CartApi.Context;
using LutryShop.CartApi.Data.ValueObjects;
using LutryShop.CartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LutryShop.CartApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CartRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CartVO> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId) ?? new CartHeader(),
            };

            cart.CartDetails = _context.CartDetails.Where(c => c.CartHeaderId == cart.CartHeader.Id)
            .Include(c => c.Product);

            return _mapper.Map<CartVO>(cart);
        }
        public async Task<CartVO> SaveOrUpdateCart(CartVO cart)
        {
            Cart mappedCart = _mapper.Map<Cart>(cart);

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == cart.CartDetails.FirstOrDefault().ProductId);

            if (product == null)
            {
                _context.Products.Add(mappedCart.CartDetails.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == mappedCart.CartHeader.UserId);
            if (cartHeader == null)
            {
                _context.CartHeaders.Add(mappedCart.CartHeader);
                await _context.SaveChangesAsync();

                mappedCart.CartDetails.FirstOrDefault().CartHeaderId = mappedCart.CartHeader.Id;
                mappedCart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(mappedCart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }else
            {
                var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProductId == mappedCart.CartDetails.FirstOrDefault().ProductId && 
                p.CartHeaderId == cartHeader.Id);
                if (cartDetail == null)
                {
                    mappedCart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                    mappedCart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(mappedCart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    mappedCart.CartDetails.FirstOrDefault().Product = null;
                    mappedCart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    mappedCart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    mappedCart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails.Update(mappedCart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartVO>(mappedCart);
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                CartDetail cartDetail = await _context.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = _context.CartDetails.Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetail);

                if (total == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeaders.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                    _context.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader= await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cartHeader!= null)
            {
                _context.CartDetails.RemoveRange(_context.CartDetails.Where(c => c.CartHeaderId == cartHeader.Id));
                _context.CartHeaders.Remove(cartHeader);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var header = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);
            if (header != null)
            {
                header.CouponCode = couponCode;
                _context.CartHeaders.Update(header);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<bool> RemoveCoupon(string userId)
        {
            var header = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);
            if (header != null)
            {
                header.CouponCode = String.Empty;
                _context.CartHeaders.Update(header);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
