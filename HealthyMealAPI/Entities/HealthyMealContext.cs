using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyMealAPI.Entities
{
    public partial class HealthyMealContext : IdentityDbContext<User>
    {
        public HealthyMealContext()
        {
        }

        public HealthyMealContext(DbContextOptions<HealthyMealContext> options)
            : base(options)
        {   
        }

        #region DbSets

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<ProductToBuy> ProductsToBuy { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<MenuString> MenuStrings { get; set; }

        public virtual DbSet<Eating> Eatings { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Units> Units { get; set; }

        public virtual DbSet<EatingType> EatingTypes { get; set; }

        public virtual DbSet<Food> Foods { get; set; }

        public virtual DbSet<CookingStep> CookingSteps { get; set; }

        public virtual DbSet<NutritionalValue> NutritionalValues { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=DESKTOP-CN8UQ7K;Database=HealthyMeal;Trusted_Connection=True;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food).WithMany(p => p.Products)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Food");

                entity.HasOne(d => d.User).WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_User");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Food");

                entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_User");
            });

            modelBuilder.Entity<ProductToBuy>(entity =>
            {
                entity.ToTable("ProductToBuy");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductsToBuy)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductToBuy_Product");

                entity.HasOne(d => d.Units).WithMany(p => p.ProductsToBuy)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductToBuy_Units");

                entity.HasOne(d => d.User).WithMany(p => p.ProductsToBuy)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductToBuy_User");
            });

            modelBuilder.Entity<Eating>(entity =>
            {
                entity.ToTable("Eating");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.EatingTypeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.NutritionalValueId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.NutritionalValue).WithMany(p => p.Eatings)
                    .HasForeignKey(d => d.NutritionalValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eating_NutritionalValue");

                entity.HasOne(d => d.EatingType).WithMany(p => p.Eatings)
                    .HasForeignKey(d => d.EatingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eating_EatingTypeId");

                entity.HasOne(d => d.User).WithMany(p => p.Eatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eating_User");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.User).WithMany(p => p.Menus)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_User");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.ToTable("Units");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EatingType>(entity =>
            {
                entity.ToTable("EatingType");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CookingStep>(entity =>
            {
                entity.ToTable("CookingStep");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe).WithMany(p => p.CookingSteps)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CookingStep_Recipe");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Product");

                entity.HasOne(d => d.Recipe).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Recipe");

                entity.HasOne(d => d.Units).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Units");
            });

            modelBuilder.Entity<MenuString>(entity =>
            {
                entity.ToTable("MenuString");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.EatingTypeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);
                
                entity.Property(e => e.MenuId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu).WithMany(p => p.MenuStrings)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuString_Menu");

                entity.HasOne(d => d.Recipe).WithMany(p => p.MenuStrings)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuString_Recipe");

                entity.HasOne(d => d.EatingType).WithMany(p => p.MenuStrings)
                    .HasForeignKey(d => d.EatingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuString_EatingTypeId");
            });

            modelBuilder.Entity<NutritionalValue>(entity =>
            {
                entity.ToTable("NutritionalValue");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food).WithMany(p => p.NutritionalValues)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NutritionalValue_Food");

                entity.HasOne(d => d.Units).WithMany(p => p.NutritionalValues)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NutritionalValue_UnitsId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
