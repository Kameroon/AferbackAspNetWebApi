using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControllerTest.Helpers
{
    public class Helper
    {

        /// <summary>
        /// -- Assert.IsFalse(AssertThrows<InvalidOperationException>(() => { })); --
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="action"></param>
        /// <param name="exceptionCondition"></param>
        /// <returns></returns>
        public static bool AssertThrows<TException>(Action action, Func<TException,
            bool> exceptionCondition = null) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException ex)
            {
                if (exceptionCondition != null)
                {
                    return exceptionCondition(ex);
                }

                return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

        /*
         * 
         // No exception thrown - test fails.
Assert.IsTrue(
    AssertThrows<InvalidOperationException>(
        () => {}));

// Wrong exception thrown - test fails.
Assert.IsTrue(
    AssertThrows<InvalidOperationException>(
        () => { throw new ApplicationException(); }));

// Correct exception thrown - test passes.
Assert.IsTrue(
    AssertThrows<InvalidOperationException>(
        () => { throw new InvalidOperationException(); }));

// Correct exception thrown, but wrong message - test fails.
Assert.IsTrue(
    AssertThrows<InvalidOperationException>(
        () => { throw new InvalidOperationException("ABCD"); },
        ex => ex.Message == "1234"));

// Correct exception thrown, with correct message - test passes.
Assert.IsTrue(
    AssertThrows<InvalidOperationException>(
        () => { throw new InvalidOperationException("1234"); },
        ex => ex.Message == "1234"));
         * 
         * */
    }
}
