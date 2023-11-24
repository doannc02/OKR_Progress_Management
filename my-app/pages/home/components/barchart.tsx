import { ApexOptions } from "apexcharts";
import ReactApexChart from "react-apexcharts";

type Props = {
  height: number;
  data: {
    label: string;
    value: number;
  }[];
};
export const BarBasic = ({ props }: { props: Props }) => {
  function SetColor(dt: { label: string; value: number }[]): string[] {
    const arrColor: string[] = [];
    for (const item of dt) {
      let color = "#007BFF";
      if (item.value < 25) {
        color = "#DC3545";
      } else if (item.value <= 50) {
        color = "#FFC107";
      } else if (item.value < 75) {
        color = "#28A745";
      }
      arrColor.push(color);
    }
    return arrColor;
  }
  const propss = {
    series: [
      {
        data: props.data.map((item) => item.value),
      },
    ],
    options: {
      chart: {
        type: "bar",
        height: 150,
      },
      plotOptions: {
        bar: {
          distributed: true,
          borderRadius: 4,
          horizontal: false,
        },
      },
      dataLabels: {
        enabled: true,
        offsetX: 0,
        offsetY: 0,
        style: {
          fontSize: "12px",
          colors: ["#fff"],
        },
      },
      xaxis: {
        categories: props.data.map((item) => item.label),
      },
      colors: SetColor(props.data),
    } as ApexOptions,
  };

  const { series, options } = propss;

  return (
    <div className="overflow-auto">
      <ReactApexChart options={options} series={series} type="bar" />
    </div>
  );
};
