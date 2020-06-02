using NUnit.Framework;


namespace Notes_CRUD_App
{
    [TestFixture]
    class DatabaseCRUDTests
    {


        [SetUp]
        public void Setup()
        {
            //for any shared things you need to setup
        }


        [Test]
        public void GetNotes_user1_ListOfNote()
        {
            var dbManager = new DatabaseAccessManager();

            var notes = dbManager.GetNotes(1);

            Assert.IsNotNull(notes);
        }


        [Test]
        public void GetUsers_allUsers_ListOfUser()
        {
            var dbManager = new DatabaseAccessManager();

            var users = dbManager.GetUsers();

            Assert.IsNotNull(users);
        }


    }
}
