using Herman.Base.EntityFrameworkCore;

namespace Herman.Base.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly BaseDbContext _context;

        public TestDataBuilder(BaseDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}



