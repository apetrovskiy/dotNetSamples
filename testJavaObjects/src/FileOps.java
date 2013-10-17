/**
 * Created with IntelliJ IDEA.
 * User: APetrovsky
 * Date: 10/17/13
 * Time: 6:44 PM
 * To change this template use File | Settings | File Templates.
 */
import java.io.File;
//import java.io.FileInputStream;
import java.io.FileInputStream;
import java.nio.file.Path;
import java.lang.String;
//import java.lang.;

public class FileOps {
    public static void main(String args[]) {

        File file = new File("D:\\20131017\\changes.txt");
        //file.
        if (null == file) {
            //println
        }
        FileInputStream fin = new FileInputStream(file);
        fin.read();
        //println(file.toPath());
        //println(file.getPath());
        //FileInputStream fin = new FileInputStream("C:\\1\\1.xml");

        //byte b = (byte) fin.read();

        //println(b);

    }
}
