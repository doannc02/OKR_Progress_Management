import "@/styles/globals.css";
import type { AppProps } from "next/app";
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import NextNProgress from 'nextjs-progressbar';
const queryClient = new QueryClient();

export default function App({ Component, pageProps }: AppProps) {
  return (
    <QueryClientProvider client={queryClient}>
      <NextNProgress color="#ffff" stopDelayMs={1500} options={{
    showSpinner: true, // Hiển thị spinner
  }}/>
       <Component {...pageProps} />
       <ReactQueryDevtools initialIsOpen={false} />
    </QueryClientProvider>
  );
}
