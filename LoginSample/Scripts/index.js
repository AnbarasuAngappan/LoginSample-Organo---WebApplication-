ej.base.enableRipple(true)

var dataManager = new ej.data.DataManager({
    url: 'http://localhost:50766/Home/ChartDetails'
});



    var chart = new ej.charts.Chart({
        //Initializing Primary X Axis
        primaryXAxis: {
            valueType: 'Category',
            labelFormat: 'y',
            majorGridLines: { width: 0 },
            intervalType: 'Minutes',
            edgeLabelPlacement: 'Shift'
        },
        //Initializing Primary Y Axis
        primaryYAxis: {
            minimum: 177000,
            maximum: 178000,
            interval: 100,
            labelFormat: '{value}',
            lineStyle: { width: 0 },
            majorTickLines: { width: 0 },
            minorTickLines: { width: 0 }
        },
        chartArea: {
            border: {
                width: 0
            }
        },
        //Initializing Chart Series
        series: [
            {
                //dataSource: [
                //    { "x": "12.15 AM", "y": 177208 }, { "x": "12.30 AM", "y": 177508 },
                //    { "x": "12.45 AM", "y": 177508 }, { "x": "1.00 AM", "y": 177256 },
                //    { "x": "1.15 AM", "y": 177608 }, { "x": "1.30 AM", "y": 177123 },
                //    { "x": "1.45 AM", "y": 177252 }, { "x": "2.00 AM", "y": 177789 },
                //    { "x": "2.15 AM", "y": 177888 }, { "x": "2.30 AM", "y": 177452 },
                //    { "x": "2.45 AM", "y": 177777 }, { "x": "3.00 AM", "y": 177665 },
                //    { "x": "3.15 AM", "y": 177208 }, { "x": "3.30 AM", "y": 177542 },
                //    { "x": "3.45 AM", "y": 177208 }, { "x": "4.00 AM", "y": 177885 },
                //    { "x": "4.15 AM", "y": 177208 }, { "x": "4.30 AM", "y": 177777 },
                //    { "x": "4.45 AM", "y": 177208 }, { "x": "5.00 AM", "y": 177885 },
                //    { "x": "5.15 AM", "y": 177208 }, { "x": "5.30 AM", "y": 177777 },
                //    { "x": "5.45 AM", "y": 177208 }, { "x": "6.00 AM", "y": 177885 },
                //    { "x": "6.15 AM", "y": 177208 }, { "x": "6.30 AM", "y": 177777 }
                //],
                dataSource: dataManager,
                name: 'APSEB - Residential - Import', xName: 'x', yName: 'y', type: 'SplineArea',
                border: { color: 'transparent' },
                opacity: 0.5
            }

        ],
        //Initializing Chart title
        title: 'Reading Summary',
        tooltip: { enable: true },
        width: ej.base.Browser.isDevice ? '100%' : '90%',
        load: function (args) {
            var selectedTheme = location.hash.split('/')[1];
            selectedTheme = selectedTheme ? selectedTheme : 'Material';
            args.chart.theme = (selectedTheme.charAt(0).toUpperCase() + selectedTheme.slice(1));
        }
    });
    chart.appendTo('#container'); 


    

