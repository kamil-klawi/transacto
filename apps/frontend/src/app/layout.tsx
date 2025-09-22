import type { Metadata } from "next";
import { ReactNode } from "react";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import {SidebarProvider, SidebarTrigger} from "@/src/components/ui/sidebar";
import {AppSidebar} from "@/src/components/app-sidebar/app-sidebar";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "Transacto",
  description: "Transacto is a student project",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: ReactNode;
}>) {
  return (
    <html lang="pl">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
      <SidebarProvider>
          <AppSidebar />
          <main className="w-full h-screen bg-zinc-100 text-zinc-700 font-sans px-4">
              <SidebarTrigger className="-mx-2" />
              {children}
          </main>
      </SidebarProvider>
      </body>
    </html>
  );
}
