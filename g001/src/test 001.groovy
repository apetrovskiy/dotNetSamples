
/**
 * Created with IntelliJ IDEA.
 * User: apetrovsky
 * Date: 9/23/13
 * Time: 9:37 PM
 * To change this template use File | Settings | File Templates.
 */

String base = 'http://chart.apis.google.com/chart?'
def params = [cht:'p3',chs:'250x100',
        chd:'t:60,40',chl:'Hello|World']
String qs = params.collect { k,v -> "$k=$v" }.join('&')

println "$base$qs"

