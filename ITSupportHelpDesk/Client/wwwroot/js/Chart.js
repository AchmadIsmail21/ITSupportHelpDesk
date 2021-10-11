$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44329/API/Cases/GetCases',
        type : "GET"
    }).done((result) => {
        console.log(result);
        var low = result.filter(data => data.priorityName === 'Low').length;
        var medium = result.filter(data => data.priorityName === 'Medium').length;
        var high = result.filter(data => data.priorityName === 'High').length;
        console.log(low);
        console.log(medium);
        console.log(high);

        var options = {
            series: [low, medium, high],
            chart: {
                type: 'pie',
                toolbar: {
                    show: true,
                    offsetX: 0,
                    offsetY: 0,
                    tools: {
                        download: true,
                        selection: true,
                        zoom: true,
                        zoomin: true,
                        zoomout: true,
                        pan: true,
                        reset: true | '<img src="/static/icons/reset.png" width="20">',
                        customIcons: []
                    },
                    export: {
                        csv: {
                            filename: undefined,
                            columnDelimiter: ',',
                            headerCategory: 'category',
                            headerValue: 'value',
                            dateFormatter(timestamp) {
                                return new Date(timestamp).toDateString()
                            }
                        },
                        svg: {
                            filename: undefined,
                        },
                        png: {
                            filename: undefined,
                        }
                    },
                    autoSelected: 'zoom'
                },
            },
            labels: ['Low', 'Medium', 'High'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };
        var chart = new ApexCharts(document.querySelector("#chartPriorityName"), options);
        chart.render();
    })
})

$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44329/API/Users/GetProfile',
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.filter(data => data.gender === "Female").length;
        var male = result.filter(data => data.gender === "Male").length;

        console.log(female);
        console.log(male);
        

        var options = {
            series: [female, male],
            chart: {
                type: 'pie',
                toolbar: {
                    show: true,
                    offsetX: 0,
                    offsetY: 0,
                    tools: {
                        download: true,
                        selection: true,
                        zoom: true,
                        zoomin: true,
                        zoomout: true,
                        pan: true,
                        reset: true | '<img src="/static/icons/reset.png" width="20">',
                        customIcons: []
                    },
                    export: {
                        csv: {
                            filename: undefined,
                            columnDelimiter: ',',
                            headerCategory: 'category',
                            headerValue: 'value',
                            dateFormatter(timestamp) {
                                return new Date(timestamp).toDateString()
                            }
                        },
                        svg: {
                            filename: undefined,
                        },
                        png: {
                            filename: undefined,
                        }
                    },
                    autoSelected: 'zoom'
                },
            },
            labels: ['Female', 'Male'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };
        var chart = new ApexCharts(document.querySelector("#chartGender"), options);
        chart.render();
    })
})

