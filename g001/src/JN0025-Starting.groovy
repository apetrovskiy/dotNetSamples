
/**
 * Created with IntelliJ IDEA.
 * User: apetrovsky
 * Date: 9/24/13
 * Time: 3:27 PM
 * To change this template use File | Settings | File Templates.
 */

String s1 = 'A string can be within single quotes on one line...'
String s2 = '''...or within triple single quotes
over many lines, ignoring // and */ and /* comment delimiters,...'''
String s3 = "...or within double quotes..."
String s4 = """...or within triple double quotes
over many lines."""

println(s1)
println(s2)
println(s3)
println(s4)

println 'hello, world' //the function 'println' prints a string then newline
print 'hello, world\n' //'print' doesn't print newline, but we can embed
//newlines ('\n' on Unix/Linux, '\r\n' on Windows)
println 'hello' + ', ' + 'world' // + joins strings together
print 'hello, '; println 'world'
//use semi-colons to join two statements on one line
println( 'hello, world' )
//can put command parameter in parens, sometimes we might have to
def a= 'world'; println 'hello, ' + a
//'def' to define a variable and give it a value
print 'hello, world'; println()
//empty parens must be used for no-arg functions; here, prints a blank line
def b= 'hello', c= 'world'; println "$b, ${c}"
//$ in print string captures variable's value

def g = 7, groovy = 10.2
//we can separate more than one defined variable by a comma
print g + ', ' + groovy + '\n' //prints: 7, 10.2
assert g + ', ' + groovy == '7, 10.2' //we can use assert statement and ==
//operator to understand examples

assert 4 * ( 2 + 3 ) - 6 == 14 //integers only
assert 2.5 + 7 == 9.5
assert 7 / 4 == 1.75 //decimal number or division converts expression to decimal

assert 2 > 3 == false
assert 7 <= 9
assert 7 != 2
assert true
assert ! false
assert 2 > 3 || 7 <= 9
assert ( 2 > 3 || 4 < 5 ) && 6 != 7

def a2
assert a2 == null
//variables defined but not given a value have special value null
def b2 = 1
assert b2 == 1
b2 = 2
assert b2 == 2 //variables can be re-assigned to
b2 = 'cat'
assert b2 == 'cat' //they can be re-assigned different types/classes of data
b2 = null
assert b2 == null //they can be unassigned

def abc= 4
def a23c= 4
def ab_c= 4
def _abc= 4

def ABC= 4
assert abc == ABC //although their values are the same...
assert ! abc.is( ABC ) //...the variables 'abc' and 'ABC' are different,
//the names being case-sensitive

/*these each produce compile errors when uncommented...
def abc //already defined
def a%c= 4 //not a valid name because it contains a symbol other than _
def 2bc= 4 //may not contain a digit in first position
*/

assert Byte.MAX_VALUE == 127
//a class can have attached variables, called 'fields'
assert Byte.parseByte('34') == 34
//a class can have attached functions, called 'methods'
def b3= new Byte('34')
//we can create an 'instance' of a class using the 'new' keyword
assert b3.intValue() == 34
//each instance can also have attached fields and methods

assert 4.class == Integer //the common types have both a short name...
assert 4.class == java.lang.Integer //...and a long name
assert 4.5.class == BigDecimal
assert 'hello, world'.class == String
def a3= 7
assert a3.class == Integer

