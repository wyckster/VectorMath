using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public static class RowReducer
    {
        public static bool Reduce( double[,] m )
        {
            int rows = m.GetLength( 0 );
            int cols = m.GetLength( 1 );

            // the matrix m is cols x rows and the last column is in x
            for( int col = 0; col < cols - 1; col++ ) {
                // find the for with the greatest magnitude;
                int maxrow = col;
                for( int row = col; row < rows; row++ ) {
                    if( Math.Abs( m[row, col] ) > Math.Abs( m[maxrow, col] ) ) {
                        maxrow = row;
                    }
                }
                if( m[maxrow, col] == 0.0 ) {
                    // can't pivot this column.
                    return false;
                }
                if( maxrow != col ) {
                    // Need to swap this row into position.
                    for( int i = 0; i < cols; ++i ) {
                        double temp = m[col, i];
                        m[col, i] = m[maxrow, i];
                        m[maxrow, i] = temp;
                    }
                }
                // Normalize this row
                double f = 1.0 / m[col, col];
                for( int i = 0; i < cols; ++i ) {
                    if( i != col ) {
                        m[col, i] *= f;
                    } else {
                        m[col, i] = 1;
                    }
                }
                // now zero out all the other rows using this pivot.
                for( int y = 0; y < rows; y++ ) {
                    if( y != col ) {
                        if( m[y, col] != 0 ) {
                            // this row needs zeroing
                            double d = m[y, col];
                            for( int x = col + 1; x < cols; x++ ) {
                                m[y, x] -= m[col, x] * d;
                            }
                            m[y, col] = 0;
                        }
                    }
                }
            }
            return true;
        }
    }
}
