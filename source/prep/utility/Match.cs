namespace prep.utility
{
    public class Match<ItemToMatch>
    {
        public static IMatchAn<ItemToMatch> Condition(Condition<ItemToMatch> condition)
        {
            return new ConditionalMatch<ItemToMatch>(condition);
        }
    }
}