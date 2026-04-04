using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Extensions;
using OnlineShop.Models;

namespace BrightMinds.Api.Extensions
{
    public static class DataSeeding
    {
        public static async Task<WebApplication> SeedAppData(this WebApplication application, ApplicationDbContext context)
        {
           

            // 1. Seed Special Tags
            if (!context.specialTags.Any())
            {
                var specialTags = new List<SpecialTag>
                {
                    new SpecialTag { Name = "جديد" },
                    new SpecialTag { Name = "الأكثر مبيعًا" },
                    new SpecialTag { Name = "عرض خاص" },
                    new SpecialTag { Name = "مناسب للهدايا" }
                };
                await context.AddRangeAsync(specialTags);
                await context.SaveChangesAsync();
            }

            // 2. Seed Product Types (Toy Categories)
            if (!context.ProductTypes.Any())
            {
                var productTypes = new List<ProductType>
                {
                    new ProductType { Name = "ألعاب تعليمية" },
                    new ProductType { Name = "سيارات ومركبات" },
                    new ProductType { Name = "دمى وعرائس" },
                    new ProductType { Name = "ألعاب ذكاء وتركيب" }
                };
                await context.AddRangeAsync(productTypes);
                await context.SaveChangesAsync();
            }

            // 3. Seed Brands (Toy Brands)
            if (!context.productBrands.Any())
            {
                var brands = new List<ProductBrand>()
                {
                    new ProductBrand { Name = "LEGO" },
                    new ProductBrand { Name = "Fisher-Price" },
                    new ProductBrand { Name = "Barbie" },
                    new ProductBrand { Name = "Hot Wheels" }
                };
                await context.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
             // 4. Seed Products (Kids Toys)
            if (!context.Products.Any())
            {
                var tagIds = await context.specialTags.Select(t => t.Id).ToListAsync();
                var brandIds = await context.productBrands.Select(t => t.Id).ToListAsync();
                var typeIds = await context.ProductTypes.Select(t => t.Id).ToListAsync();
                var random = new Random();

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "مكعبات التركيب الملونة",
                        Price = 150,
                        Image = "image1.jpg",
                        ProductColor = "متعدد الألوان",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],
                        ProductTypeId = typeIds[3 % typeIds.Count], // ألعاب تركيب
                        ProductBrandId = brandIds[0 % brandIds.Count], // LEGO
                        Description = "مجموعة مكعبات بلاستيكية تساعد على تنمية مهارات التركيب والإبداع لدى الأطفال.",
                        Quantity = 50
                    },
                    new Product
                    {
                        Name = "سيارة سباق بالتحكم عن بعد",
                        Price = 299,
                        Image = "image2.jpg",
                        ProductColor = "أحمر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[1 % typeIds.Count], // سيارات
                        ProductBrandId = brandIds[3 % brandIds.Count], // Hot Wheels
                        Description = "سيارة سباق سريعة مع جهاز تحكم عن بعد بمدى يصل إلى 20 متر.",
                        Quantity = 25
                    },
                    new Product
                    {
                        Name = "دمية الطبيبة الصغيرة",
                        Price = 180,
                        Image = "image3.jpg",
                        ProductColor = "وردي",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[2 % typeIds.Count], // دمى
                        ProductBrandId = brandIds[2 % brandIds.Count], // Barbie
                        Description = "دمية مع طقم أدوات طبية كامل لتعليم الأطفال العناية والرفق.",
                        Quantity = 30
                    },
                    new Product
                    {
                        Name = "جهاز لوحي تعليمي للأطفال",
                        Price = 450,
                        Image = "image4.jpg",
                        ProductColor = "أزرق",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count], // ألعاب تعليمية
                        ProductBrandId = brandIds[1 % brandIds.Count], // Fisher-Price
                        Description = "يحتوي على أناشيد تعليمية، أحرف، وأرقام باللغتين العربية والإنجليزية.",
                        Quantity = 15
                    },
                    new Product
                    {
                        Name = "طقم أدوات المطبخ الخشبي",
                        Price = 350,
                        Image = "image1.jpg",
                        ProductColor = "بيج/خشب",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "مطبخ خشبي متكامل يساعد الطفل على المحاكاة واللعب التخيلي.",
                        Quantity = 10
                    },
                    new Product
                    {
                        Name = "لعبة صيد السمك المغناطيسية",
                        Price = 85,
                        Image = "image2.jpg",
                        ProductColor = "أزرق فاتح",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[random.Next(typeIds.Count)],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "لعبة كلاسيكية ممتعة تزيد من تركيز الطفل وسرعة بديهته.",
                        Quantity = 40
                    },
                    new Product
                    {
                        Name = "طائرة هليكوبتر ذكية",
                        Price = 550,
                        Image = "image3.jpg",
                        ProductColor = "أسود وأصفر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[1 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "طائرة مزودة بحساسات لتجنب الاصطدام وسهلة التحكم.",
                        Quantity = 12
                    },
                    new Product
                    {
                        Name = "سبورة الرسم المغناطيسية",
                        Price = 120,
                        Image = "image4.jpg",
                        ProductColor = "أخضر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "سبورة للرسم والكتابة قابلة للمسح بسهولة دون فوضى الألوان.",
                        Quantity = 60
                    },
                       new Product
                    {
                        Name = "سبورة الرسم المغناطيسية",
                        Price = 120,
                        Image = "image4.jpg",
                        ProductColor = "أخضر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "سبورة للرسم والكتابة قابلة للمسح بسهولة دون فوضى الألوان.",
                        Quantity = 60
                    },
                          new Product
                    {
                        Name = "سبورة الرسم المغناطيسية",
                        Price = 120,
                        Image = "image4.jpg",
                        ProductColor = "أخضر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "سبورة للرسم والكتابة قابلة للمسح بسهولة دون فوضى الألوان.",
                        Quantity = 60
                    },
                             new Product
                    {
                        Name = "سبورة الرسم المغناطيسية",
                        Price = 120,
                        Image = "image4.jpg",
                        ProductColor = "أخضر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "سبورة للرسم والكتابة قابلة للمسح بسهولة دون فوضى الألوان.",
                        Quantity = 60
                    },
                                new Product
                    {
                        Name = "سبورة الرسم المغناطيسية",
                        Price = 120,
                        Image = "image4.jpg",
                        ProductColor = "أخضر",
                        IsAvailable = true,
                        SpecialTagId=tagIds[4%tagIds.Count],

                        ProductTypeId = typeIds[0 % typeIds.Count],
                        ProductBrandId = brandIds[random.Next(brandIds.Count)],
                        Description = "سبورة للرسم والكتابة قابلة للمسح بسهولة دون فوضى الألوان.",
                        Quantity = 60
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            return application;
        }
    }
}