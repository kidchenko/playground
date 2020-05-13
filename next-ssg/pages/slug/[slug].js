import Head from "next/head";

export default function Home({ slug }) {
  return <div className="container">{slug}</div>;
}

export async function getStaticProps() {
  return {
    props: {
      slug: "juca",
    },
  };
}

export async function getStaticPaths() {
  const slugs = ["juca", "juca2", "maria"];
  const paths = slugs.map((slug) => ({
    params: { slug: slug },
  }));

  return {
    paths: paths,
    fallback: false,
  };
}
