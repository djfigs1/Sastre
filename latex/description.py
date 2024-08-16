from pylatex import Document, Itemize
import re

from pylatex.utils import bold, NoEscape, escape_latex


def create_description(doc: Document, description: str | list[str]):
    if isinstance(description, list):
        create_bullets(doc, description)
    elif isinstance(description, str):
        doc.append(format_description(description))


def format_description(text: str) -> str:
    pattern = r'\*\*(.*?)\*\*'
    replacement = r'\\textbf{\1}'

    return NoEscape(re.sub(pattern, replacement, escape_latex(text)))


def create_bullets(doc: Document, bullets: list[str]):
    """
    Creates a series of LaTeX bullet points given a list of strings.
    """

    with doc.create(Itemize()) as itemize:
        for bullet in bullets:
            itemize.add_item(format_description(bullet))
