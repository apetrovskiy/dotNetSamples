
/**
 * Created with IntelliJ IDEA.
 * User: Alexander
 * Date: 9/22/13
 * Time: 9:19 PM
 * To change this template use File | Settings | File Templates.
 */

import java.awt.BorderLayout as BL
import javax.swing.WindowConstants as WC
import groovy.swing.SwingBuilder
import javax.swing.ImageIcon

def base = 'http://chart.apis.google.com/chart?'
def params = [cht:'p3',chs:'250x100',
        chd:'t:60,40',chl:'Hello|World']
String qs = params.collect { k,v -> "$k=$v" }.join('&')
/*
SwingBuilder.edtBuilder {
    frame(title:'Hello, Chart!', pack: true,
            visible:true, defaultCloseOperation:WC.EXIT_ON_CLOSE) {
        label(icon:new ImageIcon("$base$qs".toURL()),
                constraints:BL.CENTER)
    }
}

package mjg

import groovy.swing.SwingBuilder

import java.awt.BorderLayout as BL
import javax.swing.ImageIcon
import javax.swing.WindowConstants as WC

String base = 'https://chart.googleapis.com/chart?'
def params = [cht:'p3', chs:'250x100', chd:'t:60,40', chl:'Hello|World']
String qs = params.collect { it }.join('&')
println "$base$qs"

params.each { k,v ->
    assert qs.contains("$k=$v")
}
*/
new SwingBuilder().edt {
    frame(title:'Hello, Chart!', visible: true, pack: true,
            defaultCloseOperation: WC.EXIT_ON_CLOSE) {
        label(icon:new ImageIcon("$base$qs".toURL()), constraints: BL.CENTER)
    }
}
