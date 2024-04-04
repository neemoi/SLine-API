﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistance.Context;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(StoreLineContext))]
    partial class StoreLineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Persistance.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("categories_pkey");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Persistance.ChainOfStore", b =>
                {
                    b.Property<int>("ChainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("chain_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChainId"));

                    b.Property<string>("ChainName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("chain_name");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("ChainId")
                        .HasName("chain_of_stores_pkey");

                    b.ToTable("chain_of_stores", (string)null);
                });

            modelBuilder.Entity("Persistance.DeliveryOption", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("delivery_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeliveryId"));

                    b.Property<decimal?>("DeliveryPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("delivery_price");

                    b.Property<int?>("DeliveryTime")
                        .HasColumnType("integer")
                        .HasColumnName("delivery_time");

                    b.Property<int?>("StoreId")
                        .HasColumnType("integer")
                        .HasColumnName("store_id");

                    b.HasKey("DeliveryId")
                        .HasName("delivery_options_pkey");

                    b.HasIndex(new[] { "StoreId" }, "IX_delivery_options_store_id");

                    b.ToTable("delivery_options", (string)null);
                });

            modelBuilder.Entity("Persistance.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CartId")
                        .HasColumnType("integer")
                        .HasColumnName("cart_id");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("integer")
                        .HasColumnName("delivery_id");

                    b.Property<DateTime?>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("order_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("status_id");

                    b.HasKey("OrderId")
                        .HasName("orders_pkey");

                    b.HasIndex(new[] { "CartId" }, "IX_orders_cart_id");

                    b.HasIndex(new[] { "DeliveryId" }, "IX_orders_delivery_id");

                    b.HasIndex(new[] { "StatusId" }, "IX_orders_status_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Persistance.OrderItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("item_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<decimal?>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("price");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("Store")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("store");

                    b.HasKey("ItemId")
                        .HasName("order_items_pkey");

                    b.HasIndex(new[] { "OrderId" }, "IX_order_items_order_id");

                    b.HasIndex(new[] { "ProductId" }, "IX_order_items_product_id");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("Persistance.OrderStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("status_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("status_name");

                    b.HasKey("StatusId")
                        .HasName("order_statuses_pkey");

                    b.ToTable("order_statuses", (string)null);
                });

            modelBuilder.Entity("Persistance.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("Calories")
                        .HasColumnType("integer")
                        .HasColumnName("calories");

                    b.Property<decimal?>("Carbohydrates")
                        .HasPrecision(6, 2)
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("carbohydrates");

                    b.Property<string>("Composition")
                        .HasColumnType("text")
                        .HasColumnName("composition");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal?>("Fats")
                        .HasPrecision(6, 2)
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("fats");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea")
                        .HasColumnName("image");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("manufacturer");

                    b.Property<string>("ProductName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("product_name");

                    b.Property<decimal?>("Proteins")
                        .HasPrecision(6, 2)
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("proteins");

                    b.Property<int?>("ShelfLife")
                        .HasColumnType("integer")
                        .HasColumnName("shelf_life");

                    b.Property<string>("StorageConditions")
                        .HasColumnType("text")
                        .HasColumnName("storage_conditions");

                    b.Property<int?>("SubcategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("subcategory_id");

                    b.HasKey("ProductId")
                        .HasName("products_pkey");

                    b.HasIndex(new[] { "SubcategoryId" }, "IX_products_subcategory_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Persistance.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("store_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StoreId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int?>("ChainId")
                        .HasColumnType("integer")
                        .HasColumnName("chain_id");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("city");

                    b.Property<string>("StoreName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("store_name");

                    b.HasKey("StoreId")
                        .HasName("stores_pkey");

                    b.HasIndex(new[] { "ChainId" }, "IX_stores_chain_id");

                    b.ToTable("stores", (string)null);
                });

            modelBuilder.Entity("Persistance.Subcategory", b =>
                {
                    b.Property<int>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subcategory_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubcategoryId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("SubcategoryName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("subcategory_name");

                    b.HasKey("SubcategoryId")
                        .HasName("subcategories_pkey");

                    b.HasIndex(new[] { "CategoryId" }, "IX_subcategories_category_id");

                    b.ToTable("subcategories", (string)null);
                });

            modelBuilder.Entity("Persistance.UserCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cart_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CartId"));

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int?>("StoreId")
                        .HasColumnType("integer")
                        .HasColumnName("store_id");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("CartId")
                        .HasName("user_cart_pkey");

                    b.HasIndex(new[] { "ProductId" }, "IX_user_cart_product_id");

                    b.HasIndex(new[] { "StoreId" }, "IX_user_cart_store_id");

                    b.HasIndex(new[] { "UserId" }, "IX_user_cart_user_id");

                    b.ToTable("user_cart", (string)null);
                });

            modelBuilder.Entity("Persistance.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Persistance.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("warehouse_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WarehouseId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<decimal?>("ProductPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("product_price");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int?>("StoreId")
                        .HasColumnType("integer")
                        .HasColumnName("store_id");

                    b.HasKey("WarehouseId")
                        .HasName("warehouse_pkey");

                    b.HasIndex(new[] { "ProductId" }, "IX_warehouse_product_id");

                    b.HasIndex(new[] { "StoreId" }, "IX_warehouse_store_id");

                    b.ToTable("warehouse", (string)null);
                });

            modelBuilder.Entity("Persistance.DeliveryOption", b =>
                {
                    b.HasOne("Persistance.Store", "Store")
                        .WithMany("DeliveryOptions")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("delivery_options_store_id_fkey");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Persistance.Order", b =>
                {
                    b.HasOne("Persistance.UserCart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartId")
                        .HasConstraintName("orders_cart_id_fkey");

                    b.HasOne("Persistance.DeliveryOption", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryId")
                        .HasConstraintName("orders_delivery_id_fkey");

                    b.HasOne("Persistance.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("orders_status_id_fkey");

                    b.Navigation("Cart");

                    b.Navigation("Delivery");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Persistance.OrderItem", b =>
                {
                    b.HasOne("Persistance.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("order_items_order_id_fkey");

                    b.HasOne("Persistance.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("order_items_product_id_fkey");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Persistance.Product", b =>
                {
                    b.HasOne("Persistance.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .HasConstraintName("products_subcategory_id_fkey");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Persistance.Store", b =>
                {
                    b.HasOne("Persistance.ChainOfStore", "Chain")
                        .WithMany("Stores")
                        .HasForeignKey("ChainId")
                        .HasConstraintName("stores_chain_id_fkey");

                    b.Navigation("Chain");
                });

            modelBuilder.Entity("Persistance.Subcategory", b =>
                {
                    b.HasOne("Persistance.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("subcategories_category_id_fkey");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Persistance.UserCart", b =>
                {
                    b.HasOne("Persistance.Product", "Product")
                        .WithMany("UserCarts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("usercart_product_id_id_fkey");

                    b.HasOne("Persistance.Store", "Store")
                        .WithMany("UserCarts")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("usercart_store_id_id_fkey");

                    b.HasOne("Persistance.Users", "User")
                        .WithMany("UserCarts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("usercart_user_id_id_fkey");

                    b.Navigation("Product");

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistance.Warehouse", b =>
                {
                    b.HasOne("Persistance.Product", "Product")
                        .WithMany("Warehouses")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("warehouse_product_id_fkey");

                    b.HasOne("Persistance.Store", "Store")
                        .WithMany("Warehouses")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("warehouse_store_id_fkey");

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Persistance.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("Persistance.ChainOfStore", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Persistance.DeliveryOption", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Persistance.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Persistance.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Persistance.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("UserCarts");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Persistance.Store", b =>
                {
                    b.Navigation("DeliveryOptions");

                    b.Navigation("UserCarts");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Persistance.Subcategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Persistance.UserCart", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Persistance.Users", b =>
                {
                    b.Navigation("UserCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
