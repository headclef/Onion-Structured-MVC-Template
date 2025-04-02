using Infrastructure.Models;

namespace UnitTest.Mocks
{
    public static class FakeUserData
    {
        #region Methods
        public static IEnumerable<object[]> InvalidUsers =>
            new List<object[]>
            {
                new object[] { MissingId() },
                new object[] { MissingFirstName() },
                new object[] { MissingLastName() },
                new object[] { MissingEmail() },
                new object[] { MissingPassword() },
                new object[] { InvalidEmail() },
                new object[] { InvalidInsertDate() },
                new object[] { InvalidActivity() },
                new object[] { InvalidUpdateDate() }
            };

        public static UserModel ValidUserModel() => new UserModel
        {
            Id = 1,
            Username = "camilletural",
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            UpdateDate = null,
            DeleteDate = null,
            IsActive = true,
            IsDeleted = false
        };

        public static UserModel MissingId() => new UserModel
        {
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel MissingFirstName() => new UserModel
        {
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel MissingLastName() => new UserModel
        {
            FirstName = "Camille",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel MissingEmail() => new UserModel
        {
            FirstName = "Camille",
            LastName = "Tural",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel MissingPassword() => new UserModel
        {
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            InsertDate = System.DateTime.Now,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel InvalidEmail() => new UserModel
        {
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camillefurkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel InvalidInsertDate() => new UserModel
        {
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.MinValue,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel InvalidUpdateDate() => new UserModel
        {
            Id = 1,
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            UpdateDate = System.DateTime.MinValue,
            IsDeleted = false,
            IsActive = true
        };

        public static UserModel InvalidDeleteDate() => new UserModel
        {
            Id = 1,
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            DeleteDate = System.DateTime.MinValue,
            IsDeleted = true,
            IsActive = false
        };

        public static UserModel InvalidActivity() => new UserModel
        {
            FirstName = "Camille",
            LastName = "Tural",
            Email = "camille@furkantural.com",
            Password = "camillesPassword",
            InsertDate = System.DateTime.Now,
            IsDeleted = true,
            IsActive = false
        };
        #endregion
    }
}