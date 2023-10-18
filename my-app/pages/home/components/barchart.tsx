import { ApexOptions } from 'apexcharts'
import ReactApexChart from 'react-apexcharts'

type Props = {
  height: number
  data: {
    label: string
    value: number
  }[]
}
export const BarBasic = ( {props}: {props: Props }) => {
  const propss = {
    series: [
      {
        data: props.data.map((item) => item.value),
      },
    ],
    options: {
      chart: {
        type: 'bar',
        height: 350,
      },
      plotOptions: {
        bar: {
          distributed: true,
          borderRadius: 4,
          horizontal: true,
        },
      },
      dataLabels: {
        enabled: true,
        offsetX: 0,
        offsetY: 0,
        style: {
          fontSize: '12px',
          colors: ['#fff'],
        },
      },
      xaxis: {
        categories: props.data.map((item) => item.label),
      },
    } as ApexOptions,
  }

  const { series, options } = propss

  return (
    <ReactApexChart
      options={options}
      series={series}
      type='bar'
     
    />
  )
}