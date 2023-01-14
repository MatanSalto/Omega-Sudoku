using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using Omega_Sudoku.src.SudokuSolving;
using Omega_Sudoku.src.Exceptions;


namespace SudokuTesting
{
    [TestClass]
    public class SudokuSolverTests
    {
        [TestMethod]
        public void SudokuSolver_1x1ValidEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "0";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_4x4ValidEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "0000000000000000";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_9x9ValidEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_16x16ValidEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_25x25ValidEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_4x4NonEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "1000040023000003";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_9x9NonEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "800000070006010053040600000000080400003000700020005038000000800004050061900002000";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_16x16NonEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "123456780:;<=>?@?=0004;<368>29:000:>2=9?1400000768593:>@000000000023?@475<>8:;0000?;8150000072<>>@<=9260000:53484578>3<:=260019?3?12700000000=598<=6@?00;934>70009>@:;268=10000054;:=>3000278@1623614500000?9:@;000?67@14;93<5>0@>9<;00265=14?700000<9?3>@:200=1";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_25X25NonEmptyBoard_ReturnsSolution()
        {
            // Arrange
            string input = "123456789:;<=>?@0000000000BGH<15;FI48:EC3?>962@=7AF;0000?@C0000000000000000000000000H276GF15I8E4?B;C?00000000000000000000000001234IH5896D<:>;G@A?7BC=FCDIF>@1000000000000B;4AE:=@0000000000000000000000000AG?D3=EFC4B9I71:0000000000000000000000000IFG1>9H4I123?B958DE><0000000000000009FI16=BC357ED2?8:>4A;:E?CA>@27;HF1=8B000000000000000000000000071@:?E25B75D6BHE4:A@G2?;<>3F=I81C93000009?H5:=;F<A6CB@>IDG7A00IDG=>167@E35:982HB;<4?H>:@GBFD278I?1A=;<45C693E<=B?8;CI3E9HG46>FD17A:@25695;7A:<4@>BC2D?EG3IF=H1823490000000000=I@;>00000000000000000000000002=<?@4BGHDF9;CI2E>7@1000000000000<000000000000000000000000056=<:@4A?HI2CBEG39DF>1";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_1x1SolvedBoard_ReturnsSolution()
        {
            // Arrange
            string input = "1";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }


        [TestMethod]
        public void SudokuSolver_4x4SolvedBoard_ReturnsSolution()
        {
            // Arrange
            string input = "1234341221434321";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_9x9SolvedBoard_ReturnsSolution()
        {
            // Arrange
            string input = "123456789687139254495278136712893465956714823348625917261347598879561342534982671";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_16x16SolvedBoard_ReturnsSolution()
        {
            // Arrange
            string input = "123456789:;<=>?@?=@714;<368>29:5<;:>2=9?145@368768593:>@27?=14;<9123?@475<>8:;6=:6?;815=@34972<>>@<=926;?17:53484578>3<:=26;@19?3?127<84:>@6;=598<=6@?15;934>72:79>@:;268=15?<3454;:=>39<?278@16236145=>78<?9:@;=:8?67@14;93<5>2@>9<;8:265=14?73;745<9?3>@:268=1";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_25x25SolvedBoard_ReturnsSolution()
        {
            // Arrange
            string input = "123456789:;<=>?@ABCDEFGHIDBGH<15;FI48:EC3?>962@=7AF;8EI2?@CG15DAB4=H7<39:6>9:=>@3DA<H276GF15I8E4?B;C?A67C4>E=B39IH@2:F;G158<DE1234IH5896D<:>;G@A?7BC=FCDIF>@16G?=357H829<B;4AE:=@9BH:27;>F1A8G645ECD3I?<;<AG?D3=EFC4B9I71:H>6258@5678:<4BAC?2@;ED3=IFG1>9H4I123?B958DE><:GCA6;@H7F=GH@<9FI16=BC357ED2?8:>4A;:E?CA>@27;HF1=8BI459<G3D6>8F=;CG3D<IA469H71@:?E25B75D6BHE4:A@G2?;<>3F=I81C934E1289?H5:=;F<A6CB@>IDG7AFCIDG=>167@E35:982HB;<4?H>:@GBFD278I?1A=;<45C693E<=B?8;CI3E9HG46>FD17A:@25695;7A:<4@>BC2D?EG3IF=H182349156F?D<:8C=I@;>AH7EBGIC>AE78GB15;9D3FH6:2=<?@4BGHDF9;CI2E>7@15<?=48A6:3@?<:=EAH>3G6FB4987D15C;I287;56=<:@4A?HI2CBEG39DF>1";
            // Act
            string solution = Solver.Solve(input);
            // Assert
            Assert.IsNotNull(solution);
        }

        [TestMethod]
        public void SudokuSolver_InvalidCharacter_ThrowsException()
        {
            // Arrange
            string input = "1234341229434321";
            // Act => Assert
            Assert.ThrowsException<InvalidCharacterException>(() => Solver.Solve(input));
        }

        [TestMethod]
        public void SudokuSolver_InvalidLength_ThrowsException()
        {
            // Arrange
            string input = "010000000000";
            // Act => Assert
            Assert.ThrowsException<InvalidLengthException>(() => Solver.Solve(input));
        }

        [TestMethod]
        public void SudokuSolver_InvalidBoard_ThrowsException()
        {
            // Arrange
            string input = "0001000100000000";
            // Act => Assert
            Assert.ThrowsException<InvalidBoardException>(() => Solver.Solve(input));
        }

        [TestMethod]
        public void SudokuSolver_UnsolvableBoard_ThrowsException()
        {
            // Arrange
            string input = "000005080000601043000000000010500000000106000300000005530000061000000004000000000";
            // Act => Assert
            Assert.ThrowsException<UnsolvableBoardException>(() => Solver.Solve(input));
        }
    }
}